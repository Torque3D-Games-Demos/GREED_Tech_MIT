#include "shaders/common/postFx/postFx.hlsl"
#include "../../torque.hlsl"

uniform float amount;
uniform float samples;
uniform sampler2D backBuffer;

float4 main(PFXVertToPix IN) : COLOR
{
   float b = 0;
   
   float4 base = tex2D(backBuffer, IN.uv0);
   float2 uv = IN.uv0;
   
   [loop] for (int i = 1; i <= samples; i++)
   {
      uv -= b;
      uv *= amount;
      b = (1-(1*pow(abs(amount), i))) / 2;
      uv += b;
      base += tex2Dlod(backBuffer, float4(uv.x, uv.y, 0, 0));
   }
   
   return base / (samples + 1);
}