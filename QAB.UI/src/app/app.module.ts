import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CasesListComponent } from './components/cases/cases-list/cases-list.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from './components/header/header.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CustomSlicePipe } from './pipes/custom-slice.pipe';

@NgModule({
  declarations: [
    AppComponent,
    CasesListComponent,
    HeaderComponent,
    CustomSlicePipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,  
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
