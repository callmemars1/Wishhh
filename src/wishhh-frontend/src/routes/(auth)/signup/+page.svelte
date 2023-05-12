<script lang="ts">
    import Button from '$lib/components/controls/Button.svelte';
    import TextInput from '$lib/components/controls/TextInput.svelte';
    import Logo from '$lib/components/Logo.svelte';

    let login: string;
    let password: string;
    
    let result: string;
</script>

<svelte:head>
    <title>Регистрация</title>
</svelte:head>

<div>
    <form action="POST">
        <h2 class='two-columns form-header'>
            создать аккаунт
        </h2>

        <label for="login">Логин</label>
        <TextInput
                bind:inputValue={login}
                id="login"
                placeholder='логин'
                required
        />

        <label for="password">Пароль</label>
        <TextInput
                bind:inputValue={password}
                id="password"
                placeholder='пароль'
                isPassword
                required
        />

        <label for="name">Имя</label>
        <TextInput
                id="name"
                placeholder='имя'
                required
        />

        <label for="avatar">Аватар:</label>
        <input type="file" id="avatar" name="avatar" accept="image/png, image/jpeg"/>
        <div class="two-columns">
            <Button>Создать аккаунт</Button>
        </div>
    </form>
    <div class="links">
        <a href="/">
            <Logo size="20px "/>
        </a>
        <a href="/signin">уже есть аккаунт</a>
    </div>
</div>

<style lang="less">
  @import '../../../lib/themes/default';

  .links {
    margin-top: 10px;
    display: inline-flex;
    justify-content: space-between;
    width: 100%;

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
    border-bottom: 2px solid @accentBackgroundColor;
    border-top: 2px solid @accentBackgroundColor;
    padding: 30px;
    display: grid;
    grid-template-columns: auto auto;
    grid-column-gap: 20px;
    grid-row-gap: 30px;
  }

  .two-columns {
    grid-column: span 2;
  }

  .avatar {
    display: flex;
    flex-direction: row;
    gap: 20px;
    align-items: center;
  }

  input[type='file'] {
    &::file-selector-button {
      background: none;
      border: 2px solid @accentColor;
      color: inherit;
      border-radius: 5px;
      cursor: pointer;

      &:hover {
        background: @accentColor;
      }
    }


  }
</style>
