#include "shaders/common/postFx/postFx.hlsl"
#include "../../torque.hlsl"

uniform sampler2D backBuffer;

float4 main(PFXVertToPix IN) : COLOR
{
   float4 base = tex2D(backBuffer, IN.uv0);
   base.a = 1.0f;
   
   base.rgb = (base.r + base.g + base.b) / 3.0f;
   
   if (base.r < 0.5)
      base.r = 0.0f;
   else
      base.r = 1.0f;
      
   base.gb = base.r;
   
   return base;
}