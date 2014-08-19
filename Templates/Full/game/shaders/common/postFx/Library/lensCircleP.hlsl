#include "shaders/common/postFx/postFx.hlsl"
#include "shadergen:/autogenConditioners.h"

uniform sampler2D backBuffer : register(S0);
uniform float radiusX;
uniform float radiusY;

float4 main(PFXVertToPix IN) : COLOR0
{
   float4 base = tex2D(backBuffer, IN.uv0);
   float dist = distance(IN.uv0, float2(0.5,0.5));
   base.rgb *= smoothstep(radiusX, radiusY, dist);
   return base;
}