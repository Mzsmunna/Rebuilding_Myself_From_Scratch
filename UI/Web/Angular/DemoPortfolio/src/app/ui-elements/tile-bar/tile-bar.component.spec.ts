import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TileBarComponent } from './tile-bar.component';

describe('TileBarComponent', () => {
  let component: TileBarComponent;
  let fixture: ComponentFixture<TileBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TileBarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TileBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
