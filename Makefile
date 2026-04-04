BACKEND_DIR=EcoStepBackend/EcoStepBackend
BACKEND_PROJECT=$(BACKEND_DIR)/EcoStepBackend.csproj

build:
	docker compose build

up:
	docker compose up -d eco-step-app

down:
	docker compose down

lint-backend:
	dotnet build $(BACKEND_PROJECT) -c Release
	dotnet format $(BACKEND_PROJECT) --severity warn

migrate-add:
	dotnet ef migrations add $(name) --project $(BACKEND_PROJECT) --startup-project $(BACKEND_PROJECT)

migrate-up:
	docker compose run --rm --no-deps migrator bash -lc "dotnet tool install --global dotnet-ef --version 10.* && export PATH=$$PATH:/root/.dotnet/tools && rm -rf $(BACKEND_DIR)/bin $(BACKEND_DIR)/obj && dotnet restore $(BACKEND_PROJECT) --force && dotnet ef database update --project $(BACKEND_PROJECT) --startup-project $(BACKEND_PROJECT)"

migrate-remove:
	dotnet ef migrations remove --project $(BACKEND_PROJECT) --startup-project $(BACKEND_PROJECT)
