<script lang="ts">
	export let horizontal: boolean = true;
	
	let cssHorizontal = horizontal ? 'horizontal' : 'vertical';
</script>

<menu class={cssHorizontal}>
	<slot />
</menu>

<style>
	menu {
			display: flex;
			gap: 40px;
			align-items: center;
	}
	
	.vertical {
			flex-direction: column;
	}
	
	.horizontal {
			flex-direction: row;
	}
</style>