using Elements;
using Elements.Geometry;
using System.Collections.Generic;
using System.Linq;

namespace CrossFunctionOverrides
{
    public static class CrossFunctionOverrides
    {
        /// <summary>
        /// The CrossFunctionOverrides function.
        /// </summary>
        /// <param name="model">The input model.</param>
        /// <param name="input">The arguments to the execution.</param>
        /// <returns>A CrossFunctionOverridesOutputs instance containing computed results and the model with any new elements.</returns>
        public static CrossFunctionOverridesOutputs Execute(Dictionary<string, Model> inputModels, CrossFunctionOverridesInputs input)
        {
            var output = new CrossFunctionOverridesOutputs();
            var spaceBoundaries = inputModels["Space Planning Zones"].AllElementsOfType<SpaceBoundary>().Where(sb => sb.Name == "Meeting Room");
            foreach (var sb in spaceBoundaries)
            {
                // create "Proxy" element for the space boundary,
                // so we can attach new values to the element.
                var proxy = sb.Proxy("Space Planning Zones");

                // establish default door location
                var doorLocation = sb.Boundary.Perimeter.PointAt(0.4);

                if (input.Overrides?.DoorLocation != null)
                {
                    // find matching override, if any
                    var match = input.Overrides.DoorLocation.FirstOrDefault(o => o.Identity.ParentCentroid.DistanceTo(sb.ParentCentroid) < 1);
                    if (match != null)
                    {
                        // update the door location value with the overridden value
                        doorLocation = match.Value.DoorLocation;
                        // attach override's "identity" to the proxy, so that UI knows
                        // that the element had an override applied
                        Identity.AddOverrideIdentity(proxy, match);
                    }
                }
                // set up the value object containing modified properties to be attached
                // to the space boundary proxy
                var overrideValues = new Dictionary<string, object> {
                  {"Door Location", doorLocation}
                };
                // attach the values to the proxy
                Identity.AddOverrideValue(proxy, "Door Location", overrideValues);
                output.Model.AddElement(proxy);
            }
            return output;
        }
    }
}