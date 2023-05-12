<script lang="ts">
    export let width: string;
    export let height: string;

    const sizeStylesString = `
	max-width: ${width};min-width: ${width};
	max-height: ${height};min-height: ${height};
	`;
</script>

<div class='preview' style='{sizeStylesString}'>
    <div class='background'>
        <slot name='background'/>
    </div>
    <div class='top-left'>
        <slot name='top-left'/>
    </div>
    <div class='top-right'>
        <slot name='top-right'/>
    </div>
    <div class='bottom-left'>
        <slot name='bottom-left'/>
    </div>
    <div class='bottom-right'>
        <slot name='bottom-right'/>
    </div>
    <div class='center'>
        <slot name='center'/>
    </div>
</div>

<style>
    .preview {
        position: relative;
        width: 200px;
        height: 200px;

        color: inherit;
    }

    .preview .background {
        position: absolute;
        top: 0;
        left: 0;

        width: 100%;
        height: 100%;

        display: flex;
        align-items: center;
        justify-content: center;
    }

    .preview .center {
        position: absolute;
        top: 0;
        left: 0;

        width: 100%;
        height: 100%;

        display: flex;
        align-items: center;
        justify-content: center;
    }

    .preview .top-left {
        position: absolute;
        top: 0;
        left: 0;
    }

    .preview .top-right {
        position: absolute;
        top: 0;
        right: 0;
    }

    .preview .bottom-left {
        position: absolute;
        bottom: 0;
        left: 0;
    }

    .preview .bottom-right {
        position: absolute;
        bottom: 0;
        right: 0;
    }
</style>