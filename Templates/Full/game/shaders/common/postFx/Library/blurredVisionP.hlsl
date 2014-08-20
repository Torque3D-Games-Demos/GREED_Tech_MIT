#include "shaders/common/postFx/postFx.hlsl"
#include "shadergen:/autogenConditioners.h"
#include "../../torque.hlsl"

uniform sampler2D backBuffer : register(S0);
uniform float BlurredVisionIntensity;

float4 main(PFXVertToPix IN) : COLOR0
{
   float4 base = tex2D(backBuffer, IN.uv0);

   base += tex2D(backBuffer, IN.uv0+(0.001 * BlurredVisionIntensity));
   base += tex2D(backBuffer, IN.uv0+(0.003 * BlurredVisionIntensity));
   base += tex2D(backBuffer, IN.uv0+(0.005 * BlurredVisionIntensity));
   base += tex2D(backBuffer, IN.uv0+(0.007 * BlurredVisionIntensity));
   base += tex2D(backBuffer, IN.uv0+(0.009 * BlurredVisionIntensity));
   base += tex2D(backBuffer, IN.uv0+(0.011 * BlurredVisionIntensity));

   base += tex2D(backBuffer, IN.uv0-(0.001 * BlurredVisionIntensity));
   base += tex2D(backBuffer, IN.uv0-(0.003 * BlurredVisionIntensity));
   base += tex2D(backBuffer, IN.uv0-(0.005 * BlurredVisionIntensity));
   base += tex2D(backBuffer, IN.uv0-(0.007 * BlurredVisionIntensity));
   base += tex2D(backBuffer, IN.uv0-(0.009 * BlurredVisionIntensity));
   base += tex2D(backBuffer, IN.uv0-(0.011 * BlurredVisionIntensity));
   
   base = base / 15.0; // 9.5
   
   return base;
}