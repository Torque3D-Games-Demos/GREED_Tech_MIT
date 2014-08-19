#include "shaders/common/postFx/postFx.hlsl"
#include "../../torque.hlsl"

uniform sampler2D backBuffer;

float4 main(PFXVertToPix IN) : COLOR
{
   float4 base = tex2D(backBuffer, IN.uv0);
   base.a = 0;
   return float4(1.0f, 1.0f, 1.0f, 1.0f) - base;
}