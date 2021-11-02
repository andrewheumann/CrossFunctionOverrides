using Elements;
using System.Collections.Generic;

namespace CrossFunctionOverrides
{
	/// <summary>
	/// Override metadata for DoorLocationOverride
	/// </summary>
	public partial class DoorLocationOverride : IOverride
	{
        public static string Name = "Door Location";
        public static string Dependency = "Space Planning Zones";
        public static string Context = "[*discriminator=Elements.SpaceBoundary&Name=Meeting Room]";
		public static string Paradigm = "Edit";

        /// <summary>
        /// Get the override name for this override.
        /// </summary>
        public string GetName() {
			return Name;
		}

		public object GetIdentity() {

			return Identity;
		}

	}
}