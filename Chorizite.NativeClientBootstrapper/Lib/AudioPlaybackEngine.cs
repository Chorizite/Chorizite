using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.NativeClientBootstrapper.Lib {
    class AudioPlaybackEngine : IDisposable {
        private readonly IWavePlayer outputDevice;
        private readonly MixingSampleProvider mixer;

        public AudioPlaybackEngine(int sampleRate = 44100, int channelCount = 2) {
            outputDevice = new WaveOutEvent();
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channelCount));
            mixer.ReadFully = true;
            outputDevice.Init(mixer);
            outputDevice.Play();
        }

        public void PlaySound(Stream fileName) {
            var input = new WaveFileReader(fileName);
            AddMixerInput(new AutoDisposeWaveReader(input));
        }

        public void PlaySound(CachedSound sound) {
            AddMixerInput(new CachedSoundSampleProvider(sound));
        }

        private void AddMixerInput(IWaveProvider input) {
            mixer.AddMixerInput(input);
        }

        public void Dispose() {
            outputDevice.Dispose();
        }
    }
    class CachedSound {
        public float[] AudioData { get; private set; }
        public WaveFormat WaveFormat { get; private set; }
        public CachedSound(string audioFileName) {
            using (var audioFileReader = new AudioFileReader(audioFileName)) {
                WaveFormat = audioFileReader.WaveFormat;
                var wholeFile = new List<float>((int)(audioFileReader.Length / 4));
                var readBuffer = new float[audioFileReader.WaveFormat.SampleRate * audioFileReader.WaveFormat.Channels];
                int samplesRead;
                while ((samplesRead = audioFileReader.Read(readBuffer, 0, readBuffer.Length)) > 0) {
                    wholeFile.AddRange(readBuffer.Take(samplesRead));
                }
                AudioData = wholeFile.ToArray();
            }
        }
    }
    class CachedSoundSampleProvider : IWaveProvider {
        private readonly CachedSound cachedSound;
        private long position;

        public CachedSoundSampleProvider(CachedSound cachedSound) {
            this.cachedSound = cachedSound;
        }

        public int Read(byte[] buffer, int offset, int count) {
            var availableSamples = cachedSound.AudioData.Length - position;
            var samplesToCopy = Math.Min(availableSamples, count);
            Array.Copy(cachedSound.AudioData, position, buffer, offset, samplesToCopy);
            position += samplesToCopy;
            return (int)samplesToCopy;
        }

        public WaveFormat WaveFormat { get { return cachedSound.WaveFormat; } }
    }
    class AutoDisposeWaveReader : IWaveProvider {
        private readonly WaveFileReader reader;
        private bool isDisposed;
        public AutoDisposeWaveReader(WaveFileReader reader) {
            this.reader = reader;
            this.WaveFormat = reader.WaveFormat;
        }

        public int Read(byte[] buffer, int offset, int count) {
            if (isDisposed)
                return 0;
            int read = reader.Read(buffer, offset, count);
            if (read == 0) {
                reader.Dispose();
                isDisposed = true;
            }
            return read;
        }

        public WaveFormat WaveFormat { get; private set; }
    }
}
