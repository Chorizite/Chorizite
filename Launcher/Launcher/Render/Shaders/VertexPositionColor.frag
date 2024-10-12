#version 300 es
 
precision highp float;
precision highp int;
precision lowp sampler2D;
precision lowp samplerCube;

out vec4 finalColor;
in vec4 fragColor;
 
void main() {
   finalColor = fragColor;
}