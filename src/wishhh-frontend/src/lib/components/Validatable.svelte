<script lang="ts">
    import NonClickableIcon from "$lib/components/NonClickableIcon.svelte";

    export let errorMessage: string = "";
    export let iconSize: string = "40px"

    $: iconVisibility = (errorMessage !== null && errorMessage.length !== 0)
        ? 'visible'
        : 'hidden';
</script>

<div class="wrapper">
    <div class="inputs">
        <slot/>
        <span>{errorMessage}</span>
    </div>
    <div class="icon" style="visibility: {iconVisibility}">
        <NonClickableIcon name="validation-error" size="{iconSize}"/>
    </div>
</div>

<style lang="less">
  @import "../themes/default";
  
  .wrapper {
    display: inline-flex;
  }
  
  .inputs {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    inline-size: min-content;

    span {
      overflow-wrap: anywhere;
      color: @errorColor;
      font-size: medium;
    }
  }

  .icon {
    color: @errorColor;
  }
</style>