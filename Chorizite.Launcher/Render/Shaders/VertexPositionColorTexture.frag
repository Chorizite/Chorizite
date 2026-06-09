#version 330 core

out vec4 finalColor;
in vec2 fragTexCoord;
in vec4 fragColor;

uniform sampler2D _tex;
 
void main() {
	vec4 texColor = texture(_tex, fragTexCoord);
	finalColor = fragColor * texColor;
}
