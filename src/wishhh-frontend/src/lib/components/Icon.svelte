<script context='module' lang='ts'>
    import NonClickableIcon from "$lib/components/NonClickableIcon.svelte"
    
    const icons = import.meta.glob('../assets/*.*', {as: 'raw', eager: true});
    const notFound = '‽';

    function rawSVG(name: string) {
        return icons[`../assets/${name}.svg`];
    }
</script>

<script lang='ts'>
    export let name: string;
    export let size: string | undefined;
</script>

<div class="icon" on:click>
    <NonClickableIcon name="{name}" size="{size}"/>
</div>

<style lang='less'>
  @import "../themes/default";

  .icon {
    display: flex;
    align-items: center;
    justify-content: center;
    color: inherit;
  }

  .icon:hover {
    color: @accentColor;
    cursor: pointer;
  }
</style>