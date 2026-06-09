#version 330 core

out vec4 finalColor;
in vec4 fragColor;
 
void main() {
   finalColor = fragColor;
}
