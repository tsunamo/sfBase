import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { WorkingRecordsComponent } from "./working-records/working-records.component";

const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    // Lazy async modules
    {
        path: 'login', loadChildren: './+login/login.module#LoginModule'
    },
    {
        path: 'register', loadChildren: './+register/register.module#RegisterModule'
    },
    {
        path: 'profile', loadChildren: './+profile/profile.module#ProfileModule'
    },
    {
        path: 'admin', loadChildren: './+admin/admin.module#AdminModule'
    },
    {
        path: 'examples', loadChildren: './+examples/examples.module#ExamplesModule'
    },
    {
        path: 'working-records', component: WorkingRecordsComponent
    }
];

export const routing = RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules });
