namespace Editor;

public class TreeViewOverrides : TreeView
{
	protected override void PaintItem( VirtualWidget item )
	{
		item.Indent = IndentWidth * item.Column + ExpandWidth;
		item.Rect.Left += item.Indent;

		// Body
		{
			if ( item.Object is TreeNode node )
			{
				ItemPaint?.Invoke( item );
				node.OnPaint( item );
			}
			else
			{
				base.PaintItem( item );
			}
		}

		// Drop down
		if ( item.HasChildren )
		{
			var dropDownRect = item.Rect with { Left = item.Rect.Left - ExpandWidth, Width = ExpandWidth };

			if ( item.IsOpen )
			{
				Paint.SetPen( Theme.Text );
				Paint.DrawIcon( dropDownRect, "arrow_drop_down", 26, TextFlag.Center );
			}
			else
			{
				Paint.SetPen( Theme.Text.WithAlpha( 0.6f ) );
				Paint.DrawIcon( dropDownRect, "arrow_right", 26, TextFlag.Center );
			}
		}

		item.Rect.Left -= item.Indent;
	}
}
