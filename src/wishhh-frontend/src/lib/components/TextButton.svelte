<script lang='ts'>
	export let text: string;
</script>

<span on:click>{text}</span>

<style lang='less'>
  @import "../themes/default";

  span {
		font: @font;
		color: @accentForegroundColor;
		user-select: none;
  }
	
	span:hover {
    cursor: pointer;
    color: @accentColor;
	}
</style>