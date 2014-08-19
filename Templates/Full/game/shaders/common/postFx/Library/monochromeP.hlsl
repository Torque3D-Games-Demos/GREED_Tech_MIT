#include "shaders/common/postFx/postFx.hlsl"
#include "../../torque.hlsl"

uniform sampler2D backBuffer;

float4 main(PFXVertToPix IN) : COLOR
{
   float4 base = tex2D(backBuffer, IN.uv0);
   
   base.rgb = (base.r + base.g + base.b) / 3.0f;
   
   return base;
}