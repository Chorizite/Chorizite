// Uniforms
uniform float4x4 xWorld;
uniform float4x4 xProjection;

// Texture Sampler
sampler2D _tex;

struct VSInput {
    float3 inPosition : POSITION;
    float4 inColor0 : COLOR0;
    float2 inTexCoord0 : TEXCOORD0;
};

//
// PositionColorTexture
//

struct VSPositionColorTextureOutput {
    float4 position : POSITION;
    float4 fragColor : COLOR0;
    float2 fragTexCoord : TEXCOORD0;
};

// Vertex Shader
VSPositionColorTextureOutput VSPositionColorTexture(VSInput input) {
    VSPositionColorTextureOutput output;

    // Transform the position by world and projection matrices
    output.position = mul(mul(float4(input.inPosition, 1.0f), xWorld), xProjection);

    // Pass through the color and texture coordinates
    output.fragColor = input.inColor0;
    output.fragTexCoord = input.inTexCoord0;

    return output;
}

// Pixel Shader Input/Output Structure
struct PSPositionColorTextureInput {
    float4 fragColor : COLOR0;
    float2 fragTexCoord : TEXCOORD0;
};

// Pixel Shader
float4 PSPositionColorTexture(PSPositionColorTextureInput input) : COLOR {
    // Sample the texture
    float4 texColor = tex2D(_tex, input.fragTexCoord);

    // Multiply texture color with input color
    return input.fragColor * texColor;
}

// Techniques and Passes
technique PositionColorTexture {
    pass P0 {
        // Set the vertex and pixel shaders
        VertexShader = compile vs_3_0 VSPositionColorTexture();  // Compile the vertex shader
        PixelShader  = compile ps_3_0 PSPositionColorTexture();  // Compile the pixel shader
    }
}




//
// VertexPositionColor
//

struct VSVertexPositionColorOutput {
    float4 position : POSITION;
    float4 fragColor : COLOR0;
};

// Vertex Shader
VSVertexPositionColorOutput VSPositionColor(VSInput input) {
    VSVertexPositionColorOutput output;

    // Transform the position by world and projection matrices
    output.position = mul(mul(float4(input.inPosition, 1.0f), xWorld), xProjection);

    // Pass through the color
    output.fragColor = input.inColor0;

    return output;
}

// Pixel Shader Input/Output Structure
struct PSPositionColorInput {
    float4 fragColor : COLOR0;
};

// Pixel Shader
float4 PSPositionColor(PSPositionColorInput input) : COLOR {
    // Output the fragment color
    return input.fragColor;
}

// Techniques and Passes
technique PositionColor {
    pass P0 {
        // Set the vertex and pixel shaders
        VertexShader = compile vs_3_0 VSPositionColor();  // Compile the vertex shader
        PixelShader  = compile ps_3_0 PSPositionColor();  // Compile the pixel shader
    }
}