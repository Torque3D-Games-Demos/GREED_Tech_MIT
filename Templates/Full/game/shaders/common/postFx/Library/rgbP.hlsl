#include "shaders/common/postFx/postFx.hlsl"
#include "shadergen:/autogenConditioners.h"

uniform sampler2D backBuffer : register(S0);
uniform float redLevel;
uniform float greenLevel;
uniform float blueLevel;

float4 main(PFXVertToPix IN) : COLOR0
{
   float4 base = tex2D(backBuffer, IN.uv0);
   base.r *= redLevel;
   base.g *= greenLevel;
   base.b *= blueLevel;
   return base;
}