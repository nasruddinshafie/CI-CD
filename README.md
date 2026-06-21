# CI/CD Learning — Step 1 & 2

Workflow pertama: `.github/workflows/hello.yml`

## Macam mana nak test

GitHub Actions cuma run bila fail ni berada dalam repo **GitHub** (bukan local-only).
Local files ni tak akan trigger apa-apa sampai kau push ke GitHub.

1. Buat repo baru kat GitHub (boleh public, percuma & unlimited minit).
2. Push folder `ci-cd-learning` ni ke repo tu:
   ```bash
   cd ci-cd-learning
   git init
   git add .
   git commit -m "first workflow"
   git branch -M main
   git remote add origin https://github.com/<username>/<repo-name>.git
   git push -u origin main
   ```
3. Pergi ke tab **Actions** dalam repo GitHub tu — workflow "Hello CI/CD" akan auto-run.
4. Klik run tu, expand setiap step, tengok output (`echo` punya hasil akan muncul kat situ).

## Apa yang berlaku step-by-step

- `on: push` — workflow trigger automatik setiap kali ada commit baru
- `runs-on: ubuntu-latest` — GitHub sediakan mesin Linux kosong (runner) untuk run job
- `actions/checkout@v4` — "action" siap pakai dari GitHub Marketplace untuk clone kod repo masuk runner. Tanpa ni, runner takde akses kod kau langsung
- `run:` — jalankan command shell macam biasa kat terminal

## Next step (bila ni dah jalan)

- Tambah satu lagi job yang betul-betul build/test sesuatu (contoh script Python/Node ringkas)
- Cuba `on: pull_request` pula, faham beza dengan `push`
- Tambah `if:` condition kat satu step
