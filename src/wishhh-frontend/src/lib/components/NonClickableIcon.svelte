<script context='module' lang='ts'>
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

<div
        class='icon'
        style='max-width: {size};max-height: {size};min-width: {size};min-height: {size};'
>
    {@html rawSVG(name) || notFound}
</div>

<style lang='less'>
  .icon {
    display: flex;
    align-items: center;
    justify-content: center;
    color: inherit;
  }
</style>