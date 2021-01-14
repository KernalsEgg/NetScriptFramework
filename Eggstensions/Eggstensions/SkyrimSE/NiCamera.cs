namespace Eggstensions.SkyrimSE
{
	static public class NiCamera
	{
		/// <param name="niCamera">NiCamera</param>
		/// <returns>NiFrustum</returns>
		static public System.IntPtr GetViewFrustum(System.IntPtr niCamera)
		{
			if (niCamera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niCamera)); }

			return niCamera + 0x150;
		}

		/// <param name="niCamera">NiCamera</param>
		static public System.Single[,] GetWorldToCamera(System.IntPtr niCamera)
		{
			if (niCamera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niCamera)); }

			var worldToCamera = niCamera + 0x110;

			return new System.Single[,]
			{
				{ NetScriptFramework.Memory.ReadFloat(worldToCamera), NetScriptFramework.Memory.ReadFloat(worldToCamera + 0x10), NetScriptFramework.Memory.ReadFloat(worldToCamera + 0x20), NetScriptFramework.Memory.ReadFloat(worldToCamera + 0x30) },
				{ NetScriptFramework.Memory.ReadFloat(worldToCamera + 0x4), NetScriptFramework.Memory.ReadFloat(worldToCamera + 0x14), NetScriptFramework.Memory.ReadFloat(worldToCamera + 0x24), NetScriptFramework.Memory.ReadFloat(worldToCamera + 0x34) },
				{ NetScriptFramework.Memory.ReadFloat(worldToCamera + 0x8), NetScriptFramework.Memory.ReadFloat(worldToCamera + 0x18), NetScriptFramework.Memory.ReadFloat(worldToCamera + 0x28), NetScriptFramework.Memory.ReadFloat(worldToCamera + 0x38) },
				{ NetScriptFramework.Memory.ReadFloat(worldToCamera + 0xC), NetScriptFramework.Memory.ReadFloat(worldToCamera + 0x1C), NetScriptFramework.Memory.ReadFloat(worldToCamera + 0x2C), NetScriptFramework.Memory.ReadFloat(worldToCamera + 0x3C) }
			};
		}

		/// <summary>SkyrimSE.exe + 0xC65A20 (VID69265)</summary>
		/// <param name="niCamera">NiCamera</param>
		/// <param name="center">NiPoint3</param>
		static public ((System.Single x, System.Single y, System.Single z) negativeResult, (System.Single x, System.Single y, System.Single z) positiveResult) IsInCenter(System.IntPtr niCamera, (System.Single x, System.Single y, System.Single z) center, System.Single radius, System.Single delta)
		{
			if (niCamera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niCamera)); }
			// center
			// distance
			// delta

			(System.Single x, System.Single y, System.Single z) negativeResult;
			(System.Single x, System.Single y, System.Single z) positiveResult;

			var worldTransform = NiAVObject.GetWorldTransform(niCamera);
			var rotation = NiTransform.GetRotation(worldTransform);

			if (NiFrustum.GetOrthogonalProjection(niCamera))
			{
				negativeResult.z = 0.0f;
				positiveResult.z = 0.0f;
			}
			else
			{
				var viewFrustum = NiCamera.GetViewFrustum(niCamera);
				var near = NiFrustum.GetNear(viewFrustum);
				var far = NiFrustum.GetFar(viewFrustum);

				var position = NiTransform.GetPosition(worldTransform);

				var resultNumeratorZ =
					(rotation[0, 0] * (center.x - position.x))
					+ (rotation[0, 1] * (center.y - position.y))
					+ (rotation[0, 2] * (center.z - position.z))
					- near;

				negativeResult.z = (resultNumeratorZ - radius) / (far - near);
				positiveResult.z = (resultNumeratorZ + radius) / (far - near);

				// z
				if (negativeResult.z >= 0.0f)
				{
					if (positiveResult.z > 1.0f)
					{
						positiveResult.z = 1.0f;

						if (negativeResult.z > 1.0f)
						{
							negativeResult.z = 1.0f;
						}
					}
				}
				else
				{
					negativeResult.z = 0.0f;

					if (positiveResult.z > 1.0f)
					{
						positiveResult.z = 1.0f;
					}
					else if (positiveResult.z < 0.0f)
					{
						positiveResult.z = 0.0f;
					}
				}
			}

			var worldToCamera = NiCamera.GetWorldToCamera(niCamera);

			var negativeResultDenominatorX =
				((center.x - (rotation[2, 0] * radius)) * worldToCamera[0, 3])
				+ ((center.y - (rotation[2, 1] * radius)) * worldToCamera[1, 3])
				+ ((center.z - (rotation[2, 2] * radius)) * worldToCamera[2, 3])
				+ worldToCamera[3, 3];

			if (negativeResultDenominatorX > delta)
			{
				var positiveResultDenominatorX =
					((center.x + (rotation[2, 0] * radius)) * worldToCamera[0, 3])
					+ ((center.y + (rotation[2, 1] * radius)) * worldToCamera[1, 3])
					+ ((center.z + (rotation[2, 2] * radius)) * worldToCamera[2, 3])
					+ worldToCamera[3, 3];

				if (positiveResultDenominatorX > delta)
				{
					var negativeResultDenominatorY =
						((center.x - (rotation[1, 0] * radius)) * worldToCamera[0, 3])
						+ ((center.y - (rotation[1, 1] * radius)) * worldToCamera[1, 3])
						+ ((center.z - (rotation[1, 2] * radius)) * worldToCamera[2, 3])
						+ worldToCamera[3, 3];

					if (negativeResultDenominatorY > delta)
					{
						var positiveResultDenominatorY =
							((center.x + (rotation[1, 0] * radius)) * worldToCamera[0, 3])
							+ ((center.y + (rotation[1, 1] * radius)) * worldToCamera[1, 3])
							+ ((center.z + (rotation[1, 2] * radius)) * worldToCamera[2, 3])
							+ worldToCamera[3, 3];

						if (positiveResultDenominatorY > delta)
						{
							negativeResult.x =
								(
									((center.x - (rotation[2, 0] * radius)) * worldToCamera[0, 0])
									+ ((center.y - (rotation[2, 1] * radius)) * worldToCamera[1, 0])
									+ ((center.z - (rotation[2, 2] * radius)) * worldToCamera[2, 0])
									+ worldToCamera[3, 0]
								)
								/ negativeResultDenominatorX;

							positiveResult.x =
								(
									((center.x + (rotation[2, 0] * radius)) * worldToCamera[0, 0])
									+ ((center.y + (rotation[2, 1] * radius)) * worldToCamera[1, 0])
									+ ((center.z + (rotation[2, 2] * radius)) * worldToCamera[2, 0])
									+ worldToCamera[3, 0]
								)
								/ positiveResultDenominatorX;

							negativeResult.y =
								(
									((center.x - (rotation[1, 0] * radius)) * worldToCamera[0, 1])
									+ ((center.y - (rotation[1, 1] * radius)) * worldToCamera[1, 1])
									+ ((center.z - (rotation[1, 2] * radius)) * worldToCamera[2, 1])
									+ worldToCamera[3, 1]
								)
								/ negativeResultDenominatorY;

							positiveResult.y =
								(
									((center.x + (rotation[1, 0] * radius)) * worldToCamera[0, 1])
									+ ((center.y + (rotation[1, 1] * radius)) * worldToCamera[1, 1])
									+ ((center.z + (rotation[1, 2] * radius)) * worldToCamera[2, 1])
									+ worldToCamera[3, 1]
								)
								/ positiveResultDenominatorY;

							// x
							if (negativeResult.x >= -1.0f)
							{
								if (positiveResult.x > 1.0f)
								{
									positiveResult.x = 1.0f;

									if (negativeResult.x > 1.0f)
									{
										negativeResult.x = 1.0f;
									}
								}
							}
							else
							{
								negativeResult.x = -1.0f;

								if (positiveResult.x > 1.0f)
								{
									positiveResult.x = 1.0f;
								}
								else if (positiveResult.x < -1.0f)
								{
									positiveResult.x = -1.0f;
								}
							}

							// y
							if (negativeResult.y >= -1.0f)
							{
								if (positiveResult.y > 1.0f)
								{
									positiveResult.y = 1.0f;

									if (negativeResult.y > 1.0f)
									{
										negativeResult.y = 1.0f;
									}
								}
							}
							else
							{
								negativeResult.y = -1.0f;

								if (positiveResult.y > 1.0f)
								{
									positiveResult.y = 1.0f;
								}
								else if (positiveResult.y < -1.0f)
								{
									positiveResult.y = -1.0f;
								}
							}

							return (negativeResult, positiveResult);
						}
					}
				}
			}

			negativeResult.x = -1.0f;
			negativeResult.y = -1.0f;
			positiveResult.x = 1.0f;
			positiveResult.y = 1.0f;

			return (negativeResult, positiveResult);
		}
	}
}
