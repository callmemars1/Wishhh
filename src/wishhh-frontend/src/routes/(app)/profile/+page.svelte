<script lang="ts">
    import ImageStacked from "$lib/components/ImageStacked.svelte"
    import {goto} from "$app/navigation";
    import {UserData, requestUserInfo, changeName} from '$lib/services/user';
    import {signOut} from '$lib/services/auth';
    import {RequestValidationError, createSingleMessage} from "$lib/utils/requestUtilities"
    import PreloaderField from '$lib/components/PreloaderField.svelte';
    import Icon from '$lib/components/Icon.svelte';
    import Button from '$lib/components/controls/Button.svelte';
    import ValidatableFromInput from '$lib/components/ValidatableFormInput.svelte'

    const processResponse = async () => {
        let data = await requestUserInfo()
        if (data === undefined) {
            await goto('/error?status=400')
            return undefined
        }

        displayName = data?.displayName
        return data as UserData
    }

    const processSignOut = async () => {
        await signOut()
        await goto('/')
    }

    const processChangeNameRequest = async () => {
        try {
            await changeName(displayName)
            editing = false
        } catch (error: RequestValidationError) {
            let errors = error.getErrors();
            displayNameError = createSingleMessage(errors['DisplayName'])
            editing = true
        }
    }

    let processChangeNameRequestPromise;
    let promise = processResponse()
    let editing = false
    let displayName = ""
    let displayNameError = ""
</script>

<svelte:head>
    <title>Профиль</title>
</svelte:head>

<div class="wrapper">
    {#await promise}
        <PreloaderField width="400px" height="400px" radius="10px"/>
    {:then data}
        <aside>
            <div class="photo">
                <ImageStacked width="100%" height="400px">
                    <img src="{data?.imageUri}" alt="" slot="background">
                </ImageStacked>
            </div>
            <div class="name">
                {#if editing}
                    <ValidatableFromInput
                            label=""
                            bind:inputValue={displayName}
                            bind:errorValue="{displayNameError}"
                    />
                    {#await processChangeNameRequestPromise}
                        <Icon name="preloader" size="30px"/>
                    {:then _}
                        <Icon name="accept" size="30px" on:click={
                            () => processChangeNameRequestPromise = processChangeNameRequest()}/>
                    {/await}
                {:else }
                    <span>{displayName}</span>
                    <Icon name="edit" size="30px" on:click={() => editing = true}/>
                {/if}
            </div>
        </aside>
    {/await}

    <main>
        <Button>Изменить фото</Button>
        <Button on:click={() => processSignOut()}>Выйти</Button>
    </main>
</div>

<style lang="less">
  @import "../../../lib/themes/default";

  .name {
    display: inline-flex;
    width: 100%;
    align-items: center;
    justify-content: space-between;
  }

  .wrapper {
    display: grid;
    grid-template-columns: 1fr 2fr;
    grid-column-gap: 40px;
    font: @font;
  }

  .photo {
    border-radius: 20px;
    border: solid 4px @accentColor;
    width: 100%;
    overflow: hidden;
  }

  aside {
    display: flex;
    flex-direction: column;
    gap: 20px;
    align-items: flex-start;
  }

  main {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    gap: 20px;
    font-size: @size-s;
  }

  img {
    width: 100%;
    height: 100%;
    object-fit: cover;
  }
</style>
