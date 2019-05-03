Shader "ClaseVJ/Shadercito"
{
    Properties
    {
        
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

			// definir salidas y entradas de vertex shader
			struct vertexInput {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct vertexOutput {
				float4 pos : SV_POSITION;
				float4 col : COLOR;
			};
			// 2 tipos de shader
			// vertex - ejemplo: pez
			vertexOutput vert(vertexInput input) {
				vertexOutput salida;
				salida.pos = UnityObjectToClipPos(input.vertex);
				salida.col = float4(0.4, 0.8, 0.72, 0);
				return salida;
			}

			float4 frag(vertexOutput input) : COLOR {
				return input.col;
			}

			// fragment - colores
			ENDCG
		}
    }
    FallBack "Diffuse"
}
