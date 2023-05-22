<script lang='ts'>
    export let placeholder: string;
    export let inputValue: string = '';
    export let isPassword: boolean = false;
    export let idValue: string;
</script>

{#if isPassword}
    <input
            id={idValue}
            bind:value={inputValue}
            placeholder={placeholder}
            type="password"
    />
{:else }
    <input
            id={idValue}
            bind:value={inputValue}
            placeholder={placeholder}
    />
{/if}

<style lang='less'>
  @import '../../themes/default';

  input {
    border-radius: 0;
    color: inherit;
    font: @monoFont;
    background: none;
    outline: none;
    border: none;
    border-bottom: solid 1px lighten(@foregroundColor, 50%);
    padding: 0.2em 0;

    &::placeholder {
      color: fade(@foregroundColor, 40%);
    }
  }
</style>
