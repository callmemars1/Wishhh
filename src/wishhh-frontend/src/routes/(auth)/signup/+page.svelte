<script lang="ts">
    import Button from '$lib/components/controls/Button.svelte';
    import Logo from '$lib/components/Logo.svelte';
    import Icon from '$lib/components/Icon.svelte';
    import ValidatableFormInput from '$lib/components/ValidatableFormInput.svelte';
    import {RequestValidationError, createSingleMessage} from "$lib/utils/requestUtilities"
    import {
        trySignUpAndThenSignIn,
        SignupRequest
    } from '$lib/services/auth';
    import {goto} from '$app/navigation';

    let login: string;
    let loginError = ""
    
    let password: string;
    let passwordError = ""
    
    let name: string;
    let nameError = ""

    let promise: Promise<void>
    
    const nullOrEmpty = (value: string) => value === null || value.length === 0;

    const processResponse = async () => {
        try {
            await trySignUpAndThenSignIn(new SignupRequest(login, password, name))
            await goto('/wishlists')
        } catch (error: RequestValidationError) {
            let errors = error.getErrors();
            loginError = createSingleMessage(errors['Username']);
            passwordError = createSingleMessage(errors['Password']);
            nameError = createSingleMessage(errors['DisplayName']);
        }
    }
    
    const handleFormSubmit = async () => {
        promise = processResponse()
    }
</script>

<svelte:head>
    <title>Регистрация</title>
</svelte:head>

<div>
    {#await promise}
        <div class="preloader">
            <Icon name="preloader" size="256px"/>
        </div>
    {/await}
    <form action="POST">
        <h2 class='two-columns form-header'>
            создать аккаунт
        </h2>

        <ValidatableFormInput
                label="Логин"
                bind:inputValue={login}
                placeholder="логин"
                errorValue="{loginError}"
        />

        <ValidatableFormInput
                label="Пароль"
                bind:inputValue={password}
                placeholder="пароль"
                errorValue={passwordError}
                isPassword
        />

        <ValidatableFormInput
                label="Имя в профиле"
                bind:inputValue={name}
                placeholder="имя"
                errorValue="{nameError}"
        />

        <div class="two-columns">
            <Button on:click={handleFormSubmit}>
                <span>Создать аккаунт</span>
            </Button>
        </div>
    </form>
    <div class="links">
        <a href="/">
            <Logo size="30px"/>
        </a>
        <a href="/signin">уже есть аккаунт</a>
    </div>
</div>

<style lang="less">
  @import '../../../lib/themes/default';

  .preloader {
    position: absolute;
    margin-left: auto;
    margin-right: auto;
    left: 0;
    right: 0;
    width: min-content;
  }

  .links {
    margin-top: 10px;
    display: inline-flex;
    justify-content: space-between;
    align-items: center;
    width: 100%;
    font-size: large;

    a:hover {
      cursor: pointer;
      color: @accentColor;
    }
  }

  .form-header {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin-bottom: 20px;
  }

  form {
    padding-bottom: 50px;
    border-bottom: 3px solid lighten(@foregroundColor, 50%);
    display: grid;
    align-items: flex-start;
    grid-template-columns: auto auto;
    grid-column-gap: 40px;
    grid-row-gap: 30px;
    font-size: 20px;
  }

  label {
    margin-top: 100px;
  }

  .two-columns {
    grid-column: span 2;
  }
</style>
