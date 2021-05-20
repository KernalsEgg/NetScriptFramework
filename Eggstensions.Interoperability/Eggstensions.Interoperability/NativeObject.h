#pragma once



namespace Eggstensions
{
	namespace Interoperability
	{
		namespace Managed
		{
			template<class T>
			public ref class UnownedNativeObject
			{
			public:
				UnownedNativeObject(T* nativeObject)
					: _nativeObject(nativeObject)
				{
				}



				property System::IntPtr Address
				{
					System::IntPtr get()
					{
						return System::IntPtr(_nativeObject);
					}
				}

				property T* NativeObject
				{
					T* get()
					{
						return _nativeObject;
					}
				}



				static public operator System::Boolean(UnownedNativeObject^ nativeObject)
				{
					return nativeObject->NativeObject;
				}

				static public operator System::IntPtr(UnownedNativeObject^ nativeObject)
				{
					return nativeObject->Address;
				}

			private:
				T* _nativeObject;
			};

			template<class T>
			public ref class OwnedNativeObject : public UnownedNativeObject<T>
			{
			public:
				OwnedNativeObject(T* nativeObject)
					: UnownedNativeObject(nativeObject)
				{
				}

				~OwnedNativeObject()
				{
					this->!OwnedNativeObject();
				}

			protected:
				!OwnedNativeObject()
				{
					delete NativeObject;
				}
			};
		}
	}
}
