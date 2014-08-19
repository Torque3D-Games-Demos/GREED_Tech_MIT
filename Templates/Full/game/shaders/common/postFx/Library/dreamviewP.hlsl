#include "shaders/common/postFx/postFx.hlsl"
#include "shadergen:/autogenConditioners.h"
#include "../../torque.hlsl"

uniform sampler2D backBuffer : register(S0);
uniform float DreamViewIntensity;

float4 main(PFXVertToPix IN) : COLOR0
{
   float4 base = tex2D(backBuffer, IN.uv0);

   base += tex2D(backBuffer, IN.uv0+(0.001 * DreamViewIntensity));
   base += tex2D(backBuffer, IN.uv0+(0.003 * DreamViewIntensity));
   base += tex2D(backBuffer, IN.uv0+(0.005 * DreamViewIntensity));
   base += tex2D(backBuffer, IN.uv0+(0.007 * DreamViewIntensity));
   base += tex2D(backBuffer, IN.uv0+(0.009 * DreamViewIntensity));
   base += tex2D(backBuffer, IN.uv0+(0.011 * DreamViewIntensity));

   base += tex2D(backBuffer, IN.uv0-(0.001 * DreamViewIntensity));
   base += tex2D(backBuffer, IN.uv0-(0.003 * DreamViewIntensity));
   base += tex2D(backBuffer, IN.uv0-(0.005 * DreamViewIntensity));
   base += tex2D(backBuffer, IN.uv0-(0.007 * DreamViewIntensity));
   base += tex2D(backBuffer, IN.uv0-(0.009 * DreamViewIntensity));
   base += tex2D(backBuffer, IN.uv0-(0.011 * DreamViewIntensity));
   
   base.rgb = (base.r + base.g + base.b)/3.0;
   base = base / 9.5;
   
   return base;
}