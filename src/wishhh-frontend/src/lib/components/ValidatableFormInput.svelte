<script lang="ts">
    import TextInput from '$lib/components/controls/TextInput.svelte';
    import Validatable from '$lib/components/Validatable.svelte';

    export let label: string;
    export let inputValue: string;
    export let placeholder: string = "";
    export let isPassword: boolean = false;
    export let errorIconSize: string = "40px";
    export let errorValue: string = "";

    let id = (Math.random() + 1).toString(36).substring(7);
</script>

<label for="{id}">{label}</label>
<Validatable errorMessage="{errorValue}" iconSize="{errorIconSize}">
    <TextInput
            bind:inputValue={inputValue}
            idValue="{id}"
            placeholder='{placeholder}'
            isPassword={isPassword}
    />
</Validatable>

<style lang="less">

  label {
    margin-top: 5px;
  }
</style>