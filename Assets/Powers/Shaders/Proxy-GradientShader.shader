// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Proxy/GradientShader"
{
	Properties
	{
		_ColorA("ColorA", Color) = (0,0,0,0)
		_ColorB("ColorB", Color) = (0,0,0,0)
		_GradientRamp("GradientRamp", Float) = 0
		_Size("Size", Float) = 0
		_GradientDirection("GradientDirection", Vector) = (0,2,0,0)
		_Falloff("Falloff", Float) = 0
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Off
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Unlit keepalpha noshadow noambient novertexlights 
		struct Input
		{
			float3 worldPos;
		};

		uniform float4 _ColorA;
		uniform float4 _ColorB;
		uniform float3 _GradientDirection;
		uniform float _Size;
		uniform float _Falloff;
		uniform float _GradientRamp;

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float3 ase_vertex3Pos = mul( unity_WorldToObject, float4( i.worldPos , 1 ) );
			float3 temp_cast_0 = (ase_vertex3Pos.y).xxx;
			float3 temp_cast_1 = (_Size).xxx;
			float4 lerpResult4 = lerp( _ColorA , _ColorB , pow( ( distance( max( ( abs( ( temp_cast_0 - _GradientDirection ) ) - ( temp_cast_1 * float3( 0.5,0.5,0.5 ) ) ) , float3( 0,0,0 ) ) , float3( 0,0,0 ) ) / _Falloff ) , _GradientRamp ));
			o.Emission = lerpResult4.rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=16600
140;415;1286;637;1841.838;-48.18352;1;True;True
Node;AmplifyShaderEditor.PosVertexDataNode;7;-1503.835,-33.56121;Float;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;18;-1448.807,300.2206;Float;False;Property;_Size;Size;3;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;19;-1450.807,392.2206;Float;False;Property;_Falloff;Falloff;5;0;Create;True;0;0;False;0;0;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector3Node;17;-1500.228,128.4322;Float;False;Property;_GradientDirection;GradientDirection;4;0;Create;True;0;0;False;0;0,2,0;1,1,1;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;15;-1083.287,407.6374;Float;False;Property;_GradientRamp;GradientRamp;2;0;Create;True;0;0;False;0;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;16;-1158.996,188.0047;Float;False;BoxMask;-1;;1;9dce4093ad5a42b4aa255f0153c4f209;0;4;1;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;10;FLOAT3;0,0,0;False;17;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;14;-780.1196,197.9404;Float;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;2;-863.8315,-178.585;Float;False;Property;_ColorA;ColorA;0;0;Create;True;0;0;False;0;0,0,0,0;1,0.4568831,0.04245281,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;3;-875.058,9.844561;Float;False;Property;_ColorB;ColorB;1;0;Create;True;0;0;False;0;0,0,0,0;0.5754717,0.1058651,0.1058651,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;4;-484.9161,45.67389;Float;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;2;Float;ASEMaterialInspector;0;0;Unlit;Proxy/GradientShader;False;False;False;False;True;True;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;False;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;16;1;7;2
WireConnection;16;4;17;0
WireConnection;16;10;18;0
WireConnection;16;17;19;0
WireConnection;14;0;16;0
WireConnection;14;1;15;0
WireConnection;4;0;2;0
WireConnection;4;1;3;0
WireConnection;4;2;14;0
WireConnection;0;2;4;0
ASEEND*/
//CHKSM=9EC844A2F3948221C8953326379E61F21FF26B6C