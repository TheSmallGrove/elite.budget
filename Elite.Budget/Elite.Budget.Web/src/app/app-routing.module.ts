import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BudgetsPageComponent } from './pages/budgets-page/budgets-page.component';
import { DashboardPageComponent } from './pages/dashboard-page/dashboard-page.component';
import { ImportPageComponent } from './pages/import-page/import-page.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { TransactionsPageComponent } from './pages/transactions-page/transactions-page.component';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardPageComponent },
  { path: 'transactions', component: TransactionsPageComponent },
  { path: 'budgets', component: BudgetsPageComponent },
  { path: 'import', component: ImportPageComponent },
  { path: '**', component: NotFoundPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
