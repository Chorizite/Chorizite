#version 300 es

uniform mat4 xWorld;
uniform mat4 xProjection;

layout(location = 0) in vec3 inPosition;
layout(location = 1) in vec4 inColor0;
layout(location = 2) in vec2 inTexCoord0;

out vec4 fragColor;

void main() {
   gl_Position = xProjection * xWorld * vec4(inPosition, 1.0);
   fragColor = inColor0;
}