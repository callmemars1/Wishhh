<script lang='ts'>
    export let placeholder: string;
    export let inputValue: string = '';
    export let isPassword: boolean = false;
    export let required: boolean = false;
    export let id: string;

    $: inputType = isPassword ? 'password' : 'text';
</script>

<input
        id={id}
        bind:value={inputValue}
        placeholder={placeholder}
        required={required}
/>

<style lang='less'>
  @import '../../themes/default';

  input {
    color: inherit;
    font: @monoFont;
    font-size: @size-xs;
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
