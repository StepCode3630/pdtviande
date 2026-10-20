# Recipe API tests

Five simple Bruno requests, with one test per request:

1. **GET all recipes** — checks status 200 and a list response.
2. **POST Create recipe** — checks status 201, the ID and the name; saves the ID.
3. **GET Recipe by ID** — checks status 200 and the created recipe.
4. **PUT Update recipe** — checks status 204.
5. **DELETE Recipe** — checks status 204 and deletes the test recipe.

Start the API and PostgreSQL. Open this folder in Bruno, select the `env`
environment and run the collection in order. The default `host` is
`http://localhost:5010`.

POST saves `recipeId` automatically. Run it before GET by ID, PUT or DELETE.
The collection only updates and deletes the recipe it creates.

To run from this folder using the CLI:

```bash
npx --yes @usebruno/cli@4.2.1 run --env env
```
