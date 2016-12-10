Shader "Hidden/GrabBeforePixelation"
{
	Properties
	{}

	SubShader{
		Tags{"Queue"="Geometry-1"}
		GrabPass{"_BeforePixelGrab"}
	}

	Fallback "Standard"
}
