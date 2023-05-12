<script>
    import Button from '$lib/components/controls/Button.svelte';
    import TextInput from '$lib/components/controls/TextInput.svelte';
    import Logo from '$lib/components/Logo.svelte';
</script>

<svelte:head>
    <title>Войти</title>
</svelte:head>

<div>
    <form action="POST">
        <h2 class='two-columns form-header'>Вход в аккаунт</h2>

        <label for="login">Логин</label>
        <TextInput
                id="login"
                placeholder='логин'
                required
        />

        <label for="password">Пароль</label>
        <TextInput
                id="password"
                placeholder='пароль'
                isPassword
                required
        />

        <div class="two-columns">
            <Button>Войти</Button>
        </div>
    </form>
    <div class="links">
        <a href="/">
            <Logo size="20px "/>
        </a>
        <a href="/signup">регистрация</a>
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

  input[type='text'],
  input[type='password'] {
    border: none;
    border-bottom: 2px @foregroundColor solid;
    padding: 0 10px;
    font: @monoFont;
    font-size: @size-xs;

    &:focus {
      outline: none;
    }
  }
</style>
