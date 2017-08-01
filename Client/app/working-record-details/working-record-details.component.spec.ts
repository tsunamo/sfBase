import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkingRecordDetailsComponent } from './working-record-details.component';

describe('WorkingRecordDetailsComponent', () => {
  let component: WorkingRecordDetailsComponent;
  let fixture: ComponentFixture<WorkingRecordDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkingRecordDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkingRecordDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
