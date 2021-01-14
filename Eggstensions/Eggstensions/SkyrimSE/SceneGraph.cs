namespace Eggstensions.SkyrimSE
{
	static public class SceneGraph
	{
		/// <returns>SceneGraph</returns>
		static public System.IntPtr Menu3DRootNode
		{
			get
			{
				var menu3DRootNode = NetScriptFramework.Memory.ReadPointer(VIDS.SceneGraph.Menu3DRootNode);
				if (menu3DRootNode == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(menu3DRootNode)); }

				return menu3DRootNode;
			}
		}

		/// <returns>SceneGraph</returns>
		static public System.IntPtr MenuRootNode
		{
			get
			{
				var menuRootNode = NetScriptFramework.Memory.ReadPointer(VIDS.SceneGraph.MenuRootNode);
				if (menuRootNode == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(menuRootNode)); }

				return menuRootNode;
			}
		}

		/// <returns>SceneGraph</returns>
		static public System.IntPtr WorldRootNode
		{
			get
			{
				var worldRootNode = NetScriptFramework.Memory.ReadPointer(VIDS.SceneGraph.WorldRootNode);
				if (worldRootNode == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(worldRootNode)); }

				return worldRootNode;
			}
		}



		/// <param name="sceneGraph">SceneGraph</param>
		/// <returns>NiCamera</returns>
		static public System.IntPtr GetCamera(System.IntPtr sceneGraph)
		{
			if (sceneGraph == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(sceneGraph)); }

			var camera = NetScriptFramework.Memory.ReadPointer(sceneGraph + 0x128);
			if (camera == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(camera)); }

			return camera;
		}
	}
}
