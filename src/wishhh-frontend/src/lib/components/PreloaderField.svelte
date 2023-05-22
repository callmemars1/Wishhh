<script lang="ts">
    export let width: string;
    export let height: string;
    export let radius: string = "10px";

    const sizeStylesString = `
	max-width: ${width};min-width: ${width};
	max-height: ${height};min-height: ${height};
	border-radius: ${radius};`;
</script>

<div class="preloader" style="{sizeStylesString}"></div>

<style lang="less">
  .preloader {
    animation-duration: 1.8s;
    animation-fill-mode: forwards;
    animation-iteration-count: infinite;
    animation-name: placeHolderShimmer;
    animation-timing-function: linear;
    background: #b2b2b2;
    background: linear-gradient(to right, #b2b2b2 8%, lighten(#b2b2b2, 20%) 38%, #b2b2b2 54%);
    background-size: 1000px 640px;
 
    position: relative;
  }

  @keyframes placeHolderShimmer{
    0%{
      background-position: -468px 0
    }
    100%{
      background-position: 468px 0
    }
  }
</style>