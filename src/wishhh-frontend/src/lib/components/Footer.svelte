<script lang='ts'>
	import Icon from './Icon.svelte';

	let baseIconSize = 30;
</script>

<footer>
	<span> wishhh 2023 &#169; </span>
	<div class='icons-set'>
		<a href='https://github.com/callmemars1/Wishhh'>
			<Icon
				name='github'
				size='{baseIconSize + Math.trunc(baseIconSize * 0.18)}px'

			/>
		</a>
		<a href='mailto:smartynov.programms@gmail.com'>
			<Icon
				name='email'
				size='{baseIconSize + Math.trunc(baseIconSize * 0.2)}px'
			/>
		</a>
		<a href='https://t.me/smartynov0'>
			<Icon
				name='telegram'
				size='{baseIconSize}px'
			/>
		</a>
	</div>
</footer>

<style lang='less'>
  @import "../themes/default";

  footer {
		max-height: 100px;
		min-height: 100px;
		
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 20px;
    padding: 10px;

    font: @font;
    font-size: small;

    border-top: solid 2px;
		border-color: inherit;
    color: inherit;
  }

  .icons-set {
    display: flex;
    justify-content: space-around;
    align-items: center;
    gap: 50px;
  }
</style>