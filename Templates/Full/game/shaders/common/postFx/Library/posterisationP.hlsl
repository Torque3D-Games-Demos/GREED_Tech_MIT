#include "shaders/common/postFx/postFx.hlsl"
#include "shadergen:/autogenConditioners.h"

uniform sampler2D backBuffer : register(S0);
uniform float gamma;
uniform float numColors;

float4 main(PFXVertToPix IN) : COLOR0
{
   float3 base = tex2D(backBuffer, IN.uv0).rgb;
   base = pow(base, float3(gamma, gamma, gamma));
   base = base * numColors;
   base = floor(base);
   base = base / numColors;
   base = pow(base, float3(1.0/gamma, 1.0/gamma, 1.0/gamma));
   return float4(base, 1.0);
}