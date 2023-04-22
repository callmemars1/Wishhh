<script lang="ts">
	import Icon from './Icon.svelte';
	
	let baseIconSize = 40;
</script>

<footer>
	<span> wishhh 2023 &#169; </span>
	<div class='icons-set'>
		<Icon name='github' size='{baseIconSize + Math.trunc(baseIconSize * 0.18)}px' />
		<Icon name='email' size='{baseIconSize + Math.trunc(baseIconSize * 0.2)}px' />
		<Icon name='telegram' size='{baseIconSize}px' />
	</div>
</footer>

<style lang='less'>
	@import "../themes/default";
	
	footer {
		display: flex;
		flex-direction: column;
		align-items: center;
		gap: 20px;
		padding: 10px;
		
		font: @font;
		font-size: small;
		
		border-top: solid @accentColor 2px;
	}
	
	.icons-set {
		display: flex;
		justify-content: space-around;
		align-items: center;
		gap: 20%;
		color: @accentForegroundColor;
	}
</style>