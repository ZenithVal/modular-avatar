using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace nadena.dev.modular_avatar.core.editor
{
	[CustomEditor(typeof(ModularAvatarNote)), CanEditMultipleObjects]
	internal class NoteEditor : MAEditorBase
	{
		[SerializeField] private StyleSheet uss;
		[SerializeField] private VisualTreeAsset uxml;

		private SerializedProperty prop_note;

		private VisualElement 
			displayContainer,
			displayContainerButtons,
			editContainer,
			editContainerButtons;

		private Label 
			noteLabel, 
			emptyNoteLabel;
		
		private TextField noteEditTextField;
		private string tempNoteValue;

		private void OnEnable()
		{
			prop_note = serializedObject.FindProperty(nameof(ModularAvatarNote.m_note));
		}
		
		protected override void OnInnerInspectorGUI()
		{
			DrawDefaultInspector();
		}

		protected override VisualElement CreateInnerInspectorGUI()
		{
			var root = new VisualElement();
			uxml.CloneTree(root);

			displayContainer = root.Q<VisualElement>("displayContainer");
			displayContainerButtons = root.Q<VisualElement>("displayContainerButtons");
			noteLabel = root.Q<Label>("note");
			emptyNoteLabel = root.Q<Label>("emptyNote");
			
			var editButton = root.Q<Button>("editButton");
			editButton.RegisterCallback<ClickEvent>((_) => StartEditing());
			
			editContainer = root.Q<VisualElement>("editContainer");
			editContainerButtons = root.Q<VisualElement>("editContainerButtons");
			noteEditTextField = root.Q<TextField>("noteEditTextField");
			noteEditTextField.RegisterCallback<ChangeEvent<string>>((evt) => tempNoteValue = evt.newValue);
			
			var saveButton = root.Q<Button>("saveButton");
			var cancelButton = root.Q<Button>("cancelButton");
			saveButton.RegisterCallback<ClickEvent>((_) => StopEditing(true));
			cancelButton.RegisterCallback<ClickEvent>((_) => StopEditing(false));
			
			UpdateContainersVisibility(false);

			bool noteIsEmpty = string.IsNullOrWhiteSpace(prop_note.stringValue);
			UpdateLabelVisibility(noteIsEmpty);
			
			return root;
		}

		void StartEditing()
		{
			UpdateContainersVisibility(true);
			
			tempNoteValue = prop_note.stringValue;
			noteEditTextField.SetValueWithoutNotify(tempNoteValue);
		}

		void StopEditing(bool saveChanges)
		{
			UpdateContainersVisibility(false);

			if(!saveChanges)
				return;
			
			prop_note.stringValue = tempNoteValue;
			noteLabel.text = tempNoteValue;
			
			bool noteIsEmpty = string.IsNullOrWhiteSpace(tempNoteValue); 
			UpdateLabelVisibility(noteIsEmpty);

			serializedObject.ApplyModifiedProperties();
		}

		void UpdateContainersVisibility(bool isEditing)
		{
			displayContainer.style.display = isEditing ? DisplayStyle.None : DisplayStyle.Flex;
			displayContainerButtons.style.display = isEditing ? DisplayStyle.None : DisplayStyle.Flex;
			editContainer.style.display = isEditing ? DisplayStyle.Flex : DisplayStyle.None;
			editContainerButtons.style.display = isEditing ? DisplayStyle.Flex : DisplayStyle.None;
		}

		void UpdateLabelVisibility(bool noteIsEmpty)
		{
			noteLabel.style.display = noteIsEmpty ? DisplayStyle.None : DisplayStyle.Flex;
			emptyNoteLabel.style.display = noteIsEmpty ? DisplayStyle.Flex : DisplayStyle.None;
		}
	}
}