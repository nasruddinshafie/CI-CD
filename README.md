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

## Step 3: build & test sebenar (.NET)

Workflow ni sekarang ada job kedua, `build-and-test`, yang run dalam runner berasingan
secara **parallel** dengan job `greet` (dua job dalam satu workflow run serentak,
melainkan kau set `needs:` untuk buat dia tunggu).

Struktur kod:
- `src/HelloApp/` — console app ringkas dengan satu function `Calculator.Add`
- `test/HelloApp.Tests/` — xunit test untuk function tu
- `CiCdLearning.sln` — solution file supaya `dotnet restore/build/test` tau projek mana nak proses

Steps job ni:
1. `actions/setup-dotnet@v4` — pasang .NET SDK versi yang ditetapkan (8.0.x)
2. `dotnet restore` — download NuGet packages
3. `dotnet build` — compile
4. `dotnet test` — run semua test. **Kalau test fail, job ni fail** — sebab inilah CI berguna: stop kod rosak sebelum sampai jauh

## Cuba sendiri

Pecahkan test sengaja (contoh tukar `Assert.Equal(5, ...)` jadi `Assert.Equal(99, ...)`),
push, dan tengok job `build-and-test` jadi merah kat tab Actions. Lepas tu betulkan balik
dan push semula — faham macam tu lah CI "tangkap" kesilapan secara automatik.

## Next step

- Cuba `on: pull_request` pula, faham beza dengan `push`
- Tambah `needs:` untuk buat job bergantung kat job lain (contoh build-and-test kena pass dulu sebelum job deploy)
- Tambah `if:` condition kat satu step
