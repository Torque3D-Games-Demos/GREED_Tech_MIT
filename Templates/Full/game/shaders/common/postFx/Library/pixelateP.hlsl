#include "shaders/common/postFx/postFx.hlsl"
#include "shadergen:/autogenConditioners.h"

uniform sampler2D backBuffer : register(S0);
uniform float pixel_w;
uniform float pixel_h;
uniform float sizeX;
uniform float sizeY;

float4 main(PFXVertToPix IN) : COLOR0
{
   float2 uv = IN.uv0;

   float3 base = float3(1.0, 0.0, 0.0);
   float dx = pixel_w * (1.0 / sizeX);
   float dy = pixel_h * (1.0 / sizeY);
   float2 coord = float2(dx*floor(uv.x/dx), dy*floor(uv.y/dy));
   base = tex2D(backBuffer, coord).rgb;
   
   return float4(base, 1.0);
}