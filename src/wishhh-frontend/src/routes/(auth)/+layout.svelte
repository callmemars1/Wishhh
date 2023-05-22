<div class="center-placer">
    <slot/>
</div>

<style lang="less">
  @import "../../lib/themes/default";

  .center-placer {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    font: @font;
    font-size: @size-xs;
    height: 100vh;
    width: 100%;
    background: @mainBackground;
    color: @foregroundColor
  }
</style>