#include "shaders/common/postFx/postFx.hlsl"
#include "shadergen:/autogenConditioners.h"

uniform float accumTime;
uniform sampler2D backBuffer : register(S0);
uniform float intensity;

float4 main(PFXVertToPix IN) : COLOR0
{
   float2 coords = IN.uv0;
   float2 uv = IN.uv0;
   
   coords = (coords - 0.5) * 2.0;
   
   float coordDot = dot(coords, coords);
   
   float2 uvG = uv - tex2D(backBuffer, IN.uv0).xy * intensity * coords * coordDot;
   
   float4 base = tex2D(backBuffer, IN.uv0);
   
   base.g = tex2D(backBuffer, uvG).g;
   
   return base;
}