using UnityEditor;
using UnityEngine;

namespace nadena.dev.modular_avatar.core.editor
{
	[CustomEditor(typeof(ModularAvatarNote))]
	internal class NoteEditor : MAEditorBase
	{
		private SerializedProperty
			prop_note;

		private bool isEditing = false;
		private GUIStyle noteStyle;

		private void OnEnable()
		{
			prop_note = serializedObject.FindProperty(nameof(ModularAvatarNote.m_note));
		}

		protected override void OnInnerInspectorGUI()
		{
			serializedObject.Update();

			if (isEditing)
			{
				EditorGUILayout.PropertyField(prop_note);
			}
			else
			{
				EditorGUILayout.HelpBox(prop_note.stringValue, MessageType.None);
			}

			if (GUILayout.Button("Edit"))
			{
				isEditing = !isEditing;
			}

			serializedObject.ApplyModifiedProperties();
			Localization.ShowLanguageUI();
		}
	}
}