import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FamousPeopleCardComponent } from './famous-people-card.component';

describe('FamousPeopleCardComponent', () => {
  let component: FamousPeopleCardComponent;
  let fixture: ComponentFixture<FamousPeopleCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FamousPeopleCardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FamousPeopleCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
