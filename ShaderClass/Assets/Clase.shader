Shader "ClaseVJ/Shadercito"
{
	// Fernando Martinez A01630401
    Properties
    {
        _Ambient("Ambient Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
		Pass {

			Tags {"LightMode" = "ForwardBase"}

			CGPROGRAM
			// CG
			// lenguaje de shader de nvidia

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			//uniform variables
			// modificador a variables que indica que vienen del exterior
			uniform float4 _Ambient;
			uniform float4 _LightColor0;

			// definir salidas y entradas de vertex shader
			struct vertexInput {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct vertexOutput {
				float4 pos : SV_POSITION;
				float4 col : COLOR;
				float3 normal : NORMAL;
			};
			// 2 tipos de shader
			// vertex - ejemplo: pez
			vertexOutput vert(vertexInput input) {
				vertexOutput salida;
				salida.pos = UnityObjectToClipPos(input.vertex);
				salida.col = float4(0.4, 0.8, 0.72, 0);
				salida.normal = input.normal;
				return salida;
			}

			float4 frag(vertexOutput input) : COLOR{

				// Ambiental
				float4 colorA = _Ambient * _LightColor0 * 0.2;

				// en fragment el shader se ve mas suave
				float3 n = normalize(mul(float4(input.normal, 0), unity_WorldToObject));
				float3 l = normalize(_WorldSpaceLightPos0.xyz);

				float4 colorD = _LightColor0 * _Ambient * max(0.0, dot(n,l));

				return colorA + colorD;
			}

			// fragment - colores
			ENDCG
		}
    }
    FallBack "Diffuse"
}
