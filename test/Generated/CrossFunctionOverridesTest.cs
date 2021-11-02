
// This code was generated by Hypar.
// Edits to this code will be overwritten the next time you run 'hypar test generate'.
// DO NOT EDIT THIS FILE.

using Elements;
using Xunit;
using System.IO;
using System.Collections.Generic;
using Elements.Serialization.glTF;

namespace CrossFunctionOverrides
{
    public class CrossFunctionOverridesTest
    {
        [Fact]
        public void TestExecute()
        {
            var input = GetInput();

            var modelDependencies = new Dictionary<string, Model> { 
                {"Space Planning Zones", Model.FromJson(File.ReadAllText(@"/Users/andrewheumann/Dev/CrossFunctionOverrides/test/Generated/CrossFunctionOverridesTest/model_dependencies/Space Planning Zones/model.json")) }, 
            };

            var result = CrossFunctionOverrides.Execute(modelDependencies, input);
            result.Model.ToGlTF("../../../Generated/CrossFunctionOverridesTest/results/CrossFunctionOverridesTest.gltf", false);
            result.Model.ToGlTF("../../../Generated/CrossFunctionOverridesTest/results/CrossFunctionOverridesTest.glb");
            File.WriteAllText("../../../Generated/CrossFunctionOverridesTest/results/CrossFunctionOverridesTest.json", result.Model.ToJson());
        }

        public CrossFunctionOverridesInputs GetInput()
        {
            var inputText = @"
            {
  ""model_input_keys"": {
    ""Space Planning Zones"": ""58987ad8-67cc-470f-8cba-a4eb001f1ccd_09b8407f-6c93-4741-ad6c-31288213f4f7_elements.zip""
  },
  ""overrides"": {
    ""Door Location"": [
      {
        ""value"": {
          ""Door Location"": {
            ""X"": 20.559288675246556,
            ""Y"": 26.568,
            ""Z"": -1.8318679906315083E-15
          }
        },
        ""identity"": {
          ""ParentCentroid"": {
            ""X"": 23.10974,
            ""Y"": 29.567999999999998,
            ""Z"": 0.3
          }
        },
        ""id"": ""5c931b83-a7eb-456a-95b2-6d65df5e6d66""
      }
    ]
  },
  ""Length"": 1,
  ""Width"": 1
}
            ";
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CrossFunctionOverridesInputs>(inputText);
        }
    }
}